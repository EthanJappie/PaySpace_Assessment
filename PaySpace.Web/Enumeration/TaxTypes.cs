using System.ComponentModel.DataAnnotations;

namespace PaySpace.Web.Enumeration
{
    public enum TaxTypes
    {
        Progressive = 1,
        [Display(Name = "Flat Value")]
        FlatValue,
        [Display(Name = "Flat Rate")]
        FlatRate
    }
}
