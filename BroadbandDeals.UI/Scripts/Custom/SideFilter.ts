class SidebarModel {
    selectedProductTypes: KnockoutObservableArray<any>;
    selectedSpeed: KnockoutObservable<string>;
    availableProductTypes: string[];
    availableSpeedList: string[];
    showLoadingIcon: KnockoutObservable<boolean>;
    constructor(selectedProductTypes: any, selectedSpeed) {
        console.log(selectedProductTypes);
        this.availableProductTypes = ['Broadband', 'TV', 'Mobile'];
        this.availableSpeedList = ['17', '52', '76'];
        this.selectedProductTypes = ko.observableArray(selectedProductTypes == null ? [] : selectedProductTypes as any[]);
        this.selectedSpeed = ko.observable(selectedSpeed == null ? '' : selectedSpeed);
        this.showLoadingIcon = ko.observable(false);
    }

    
    //Load Deals based on product types and speed
    roadGrid = (event) => {
        this.showLoadingIcon(true);
        window.location.href = this.getDealsUrl();
        return true;
    }

     //Construct Deals Url
    getDealsUrl = () => {

        var url = '/BroadBand/Index';
        let query = "";

        if (this.selectedProductTypes() != null && this.selectedProductTypes().length > 0 && this.selectedSpeed() == null) {
            query = '?selectedProductTypes=' + this.selectedProductTypes().join(',');
        }
        if ((this.selectedProductTypes() == null || this.selectedProductTypes().length <= 0) && this.selectedSpeed() != null) {
            query = '?selectedSpeed=' + this.selectedSpeed();
        }
        if (this.selectedProductTypes() != null && this.selectedProductTypes().length > 0 && this.selectedSpeed() != null) {
            query = '?selectedProductTypes=' + this.selectedProductTypes().join(',') + '&selectedSpeed=' + this.selectedSpeed();
        }
        return url + query;
    }
}