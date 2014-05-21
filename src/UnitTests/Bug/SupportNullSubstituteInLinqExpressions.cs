using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Mappers;
using Should;
using Xunit;

namespace AutoMapper.UnitTests.Bug
{
    public class SupportNullSubstituteInLinqExpressionsBug : AutoMapperSpecBase
    {
        public class Source
        {
            public int? Value { get; set; }
        }

        public class Destination
        {
            public int Value { get; set; }
        }

        [Fact]
        public void Should_map_all_null_values_to_its_substitute_obj_to_obj()
        {
            Mapper.CreateMap<Source, Destination>()
                .ForMember(dest => dest.Value, opt => opt.NullSubstitute(42));

            var sources = new[] { new Source() }.AsQueryable();

            var destinations = sources.Select(source => Mapper.Map<Source, Destination>(source)).ToList();
            destinations[0].Value.ShouldEqual(42);
        }

        [Fact]
        public void Should_map_all_null_values_to_its_substitute_ef_to_obj()
        {
            Mapper.CreateMap<Data.Samples.EF5.Source, Destination>()
                .ForMember(dest => dest.Value, opt => opt.NullSubstitute(42));

            var sources = new[] { new Data.Samples.EF5.Source() }.AsQueryable();

            var destinations = sources.Select(source => Mapper.Map<Data.Samples.EF5.Source, Destination>(source)).ToList();
            destinations[0].Value.ShouldEqual(42);
        }

        [Fact]
        public void Should_map_all_null_values_to_its_substitute_obj_to_ef()
        {
            Mapper.CreateMap<Source, Data.Samples.EF5.Destination>()
                .ForMember(dest => dest.Value, opt => opt.NullSubstitute(42));

            var sources = new[] { new Source() }.AsQueryable();

            var destinations = sources.Select(source => Mapper.Map<Source, Data.Samples.EF5.Destination>(source)).ToList();
            destinations[0].Value.ShouldEqual(42);
        }

        [Fact]
        public void Should_map_all_null_values_to_its_substitute_obj_to_ef_with_st()
        {
            Mapper.CreateMap<Source, Data.Samples.EF5WithSelfTackingEntities.Destination>()
                .ForMember(dest => dest.Value, opt => opt.NullSubstitute(42));

            var sources = new[] { new Source() }.AsQueryable();

            var destinations = sources.Select(source => Mapper.Map<Source, Data.Samples.EF5WithSelfTackingEntities.Destination>(source)).ToList();
            destinations[0].Value.ShouldEqual(42);
        }

        [Fact]
        public void Should_map_all_null_values_to_its_substitute_ef_with_st_to_obj()
        {
            Mapper.CreateMap<Data.Samples.EF5WithSelfTackingEntities.Source, Destination>()
                .ForMember(dest => dest.Value, opt => opt.NullSubstitute(42));

            var sources = new[] { new Data.Samples.EF5WithSelfTackingEntities.Source() }.AsQueryable();

            var destinations = sources.Select(source => Mapper.Map<Data.Samples.EF5WithSelfTackingEntities.Source, Destination>(source)).ToList();
            destinations[0].Value.ShouldEqual(42);
        }

        [Fact]
        public void Should_map_all_null_values_to_its_substitute_ef_to_ef()
        {
            Mapper.CreateMap<Data.Samples.EF5.Source, Data.Samples.EF5.Destination>()
                .ForMember(dest => dest.Value, opt => opt.NullSubstitute(42));

            var sources = new[] { new Data.Samples.EF5.Source() }.AsQueryable();

            var destinations = sources.Select(source => Mapper.Map<Data.Samples.EF5.Source, Data.Samples.EF5.Destination>(source)).ToList();
            destinations[0].Value.ShouldEqual(42);
        }

        [Fact]
        public void Should_map_all_null_values_to_its_substitute_ef_with_st_to_ef_with_st()
        {
            Mapper
                .CreateMap
                <Data.Samples.EF5WithSelfTackingEntities.Source, Data.Samples.EF5WithSelfTackingEntities.Destination>()
                .ForMember(dest => dest.Value, opt => opt.NullSubstitute(42));

            var sources = new[] { new Data.Samples.EF5WithSelfTackingEntities.Source() }.AsQueryable();

            var destinations = sources.Select(source => Mapper.Map<Data.Samples.EF5WithSelfTackingEntities.Source, Data.Samples.EF5WithSelfTackingEntities.Destination>(source)).ToList();
            destinations[0].Value.ShouldEqual(42);
        }
    }
}
