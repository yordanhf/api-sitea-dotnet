using System.ComponentModel.DataAnnotations;

namespace ApiSitea.Domain.Enums
{
    public enum Provincias
    {
        [Display(Name = "Pinar del Río")]
        PinarDelRio = 1,

        [Display(Name = "Artemisa")]
        Artemisa = 2,

        [Display(Name = "La Habana")]
        LaHabana = 3,

        [Display(Name = "Mayabeque")]
        Mayabeque = 4,

        [Display(Name = "Matanzas")]
        Matanzas = 5,

        [Display(Name = "Cienfuegos")]
        Cienfuegos = 6,

        [Display(Name = "Villa Clara")]
        VillaClara = 7,

        [Display(Name = "Sancti Spíritus")]
        SanctiSpiritus = 8,

        [Display(Name = "Ciego de Ávila")]
        CiegoDeAvila = 9,

        [Display(Name = "Camagüey")]
        Camaguey = 10,

        [Display(Name = "Las Tunas")]
        LasTunas = 11,

        [Display(Name = "Holguín")]
        Holguin = 12,

        [Display(Name = "Granma")]
        Granma = 13,

        [Display(Name = "Santiago de Cuba")]
        SantiagoDeCuba = 14,

        [Display(Name = "Guantánamo")]
        Guantanamo = 15,

        [Display(Name = "Isla de la Juventud")]
        IslaDeLaJuventud = 16
    }
}
