var SidebarModel = (function () {
    function SidebarModel(selectedProductTypes, selectedSpeed) {
        var _this = this;
        //Load Deals based on product types and speed
        this.roadGrid = function (event) {
            _this.showLoadingIcon(true);
            window.location.href = _this.getDealsUrl();
            return true;
        };
        //Construct Deals Url
        this.getDealsUrl = function () {
            var url = '/BroadBand/Index';
            var query = "";
            if (_this.selectedProductTypes() != null && _this.selectedProductTypes().length > 0 && _this.selectedSpeed() == null) {
                query = '?selectedProductTypes=' + _this.selectedProductTypes().join(',');
            }
            if ((_this.selectedProductTypes() == null || _this.selectedProductTypes().length <= 0) && _this.selectedSpeed() != null) {
                query = '?selectedSpeed=' + _this.selectedSpeed();
            }
            if (_this.selectedProductTypes() != null && _this.selectedProductTypes().length > 0 && _this.selectedSpeed() != null) {
                query = '?selectedProductTypes=' + _this.selectedProductTypes().join(',') + '&selectedSpeed=' + _this.selectedSpeed();
            }
            return url + query;
        };
        console.log(selectedProductTypes);
        this.availableProductTypes = ['Broadband', 'TV', 'Mobile'];
        this.availableSpeedList = ['17', '52', '76'];
        this.selectedProductTypes = ko.observableArray(selectedProductTypes == null ? [] : selectedProductTypes);
        this.selectedSpeed = ko.observable(selectedSpeed == null ? '' : selectedSpeed);
        this.showLoadingIcon = ko.observable(false);
    }
    return SidebarModel;
}());
//# sourceMappingURL=SideFilter.js.map