using Microsoft.OpenApi.Attributes;

namespace PaySpace.Api.Enumeration
{
    public enum TaxTypes
    {

        Progressive = 1,
        [Display(name: "Flat Value")]
        FlatValue,
        [Display(name: "Flat Rate")]
        FlatRate
    }
}
