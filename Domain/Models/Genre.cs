using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public enum Genre
    {
        [Description("Fantasy")]
        Fantasy,
        [Description("Adventure")]
        Adventure,
        [Description("Romance")]
        Romance,
        [Description("Contemporary")]
        Contemporary,
        [Description("Dystopian")]
        Dystopian,
        [Description("Mystery")]
        Mystery,
        [Description("Horror")]
        Horror,
        [Description("Thriller")]
        Thriller,
        [Description("Paranormal")]
        Paranormal,
        [Description("Historical Fiction")]
        Historical_Fiction,
        [Description("Science Fiction")]
        Science_Fiction,
        [Description("Memoir")]
        Memoir,
        [Description("Cooking")]
        Cooking,
        [Description("Art")]
        Art,
        [Description("Personal")]
        Personal,
        [Description("Development")]
        Development,
        [Description("Motivational")]
        Motivational,
        [Description("Health")]
        Health,
        [Description("History")]
        History,
        [Description("Travel")]
        Travel,
        [Description("Guide")]
        Guide,
        [Description("Relationships")]
        Relationships,
        [Description("Humor")]
        Humor,
        [Description("Children")]
        Children
    }
}
