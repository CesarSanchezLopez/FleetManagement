using Mapster;
using System.Collections.Generic;

namespace FleetManagement.Application.Helpers
{
    public static class MapperHelper
    {
        // Mapea un objeto a otro tipo
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TDestination>();
        }

        // Mapea una lista de objetos a otra lista de otro tipo
        public static List<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return source.Adapt<List<TDestination>>();
        }
    }
}