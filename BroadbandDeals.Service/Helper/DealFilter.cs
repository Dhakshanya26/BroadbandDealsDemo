using BroadbandDeals.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BroadbandDeals.Service.Helper
{
    public class DealFilter : IDealSpecificFilter
    {
        private readonly List<string> _selectedProductTypes;
        private readonly string _selectedSpeed;
        private readonly bool _hasBroadband;
        public DealFilter(List<string> selectedProductTypes = null, string selectedSpeed = null)
        {
            _selectedProductTypes = selectedProductTypes;
            _selectedSpeed = selectedSpeed;
            _hasBroadband = _selectedProductTypes.Any(x => string.Equals(x, "Broadband", StringComparison.OrdinalIgnoreCase));
        }

        public bool Match(Deal deal)
        {

            if (_selectedProductTypes == null && !_selectedProductTypes.Any() && string.IsNullOrEmpty(_selectedSpeed)) return true;

            if ((_selectedProductTypes != null && _selectedProductTypes.Any()) && string.IsNullOrEmpty(_selectedSpeed))
            {

               
                if (_hasBroadband)
                {
                    var productTypesWithoutBroadband = _selectedProductTypes.Where(l => !string.Equals(l, "Broadband", StringComparison.OrdinalIgnoreCase))?.ToList();


                    var result = !productTypesWithoutBroadband.Any() ?
                             (deal.ProductTypes.Any(r => string.Equals(r, "Broadband", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(r, "Fibre Broadband", StringComparison.OrdinalIgnoreCase)))
                     :
                            deal.ProductTypes.All(y => productTypesWithoutBroadband.Contains(y) &&
                     (deal.ProductTypes.Any(r => string.Equals(r, "Broadband", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(r, "Fibre Broadband", StringComparison.OrdinalIgnoreCase))));
                    return result;
                }
                else
                {
                    return _selectedProductTypes.All(y => deal.ProductTypes.Contains(y));
                }

            }
            else if ((_selectedProductTypes == null && !_selectedProductTypes.Any()) && !string.IsNullOrEmpty(_selectedSpeed))
            {
                return deal.Speed != null && string.Equals(deal.Speed.Label, _selectedSpeed, StringComparison.OrdinalIgnoreCase);
            }
            else
            {

                return deal.Speed != null && string.Equals(deal.Speed.Label, _selectedSpeed, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}