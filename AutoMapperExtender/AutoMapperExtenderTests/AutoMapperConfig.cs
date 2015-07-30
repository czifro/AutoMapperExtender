using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperExtender;

namespace AutoMapperExtenderTests
{
    public class AutoMapperConfig
    {
        public static void ConfigureIgnoreExtraProperties()
        {
            Mapper.CreateMap<C, A>()
                .IgnoreExtraProperties();

            Mapper.AssertConfigurationIsValid();
        }

        public static void ConfigureMapFromProperty()
        {
            Mapper.CreateMap<B, A>()
                .MapFromProperty(src => src.PropA)
                .IgnoreExtraProperties();

            Mapper.AssertConfigurationIsValid();
        }
    }
}
