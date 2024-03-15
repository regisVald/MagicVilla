using MagicVilla_API.Modelos.Dto;

namespace MagicVilla_API.Datos
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto> { 
        
            new VillaDto {Id= 1, nombre = "Vista a la Piscina", ocupante = 3, MetroCuadrado = 50},
            new VillaDto {Id= 2, nombre = "Vista a la Playa", ocupante = 4, MetroCuadrado = 80}

        };
    }
}
