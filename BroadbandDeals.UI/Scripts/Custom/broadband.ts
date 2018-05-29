/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../typings/knockout.validation/knockout.validation.d.ts" />


class BroadbandModel {

    deals: any[];
    constructor(model: any) {
        this.deals = model.DealModels;
    }
}