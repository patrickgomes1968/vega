using AutoMapper;
using System.Linq;
using vega.Controllers.Resources;
using vega.Models;
using System.Collections.Generic;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone } ))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
              .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
							.ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone } ))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new FeatureResource {Id = vf.Feature.Id, Name = vf.Feature.Name})));

           // API Resource to Domain
            CreateMap<SaveVehicleResource, Vehicle>()
              .ForMember(v => v.Id, opt => opt.Ignore())
              .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
              .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
              .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
              .ForMember(v => v.Features, opt => opt.Ignore())
              .AfterMap((vr, v) => {
                //remove unselected features
                var removedFeatures = new List<VehicleFeature>();
                //Step 1. first find the features in v but not vr
                foreach (var f in v.Features)
                    if (!vr.Features.Contains(f.FeatureId))
                        removedFeatures.Add(f); // can't remove from v as this is in an iteration of v.features
                //The Linq way to do the above:
                //var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                
                //Step 2. now remove from v
                foreach (var f in removedFeatures)
                    v.Features.Remove(f);

                //now to add new features
                foreach (var id in vr.Features)
                    if (!v.Features.Any(f => f.FeatureId == id))
                        //Add to v.Features
                        v.Features.Add(new VehicleFeature{FeatureId = id});
                //  The Linq way to do the above:
                 var addedFeatures = vr.Features
                     .Where(id => !v.Features.Any(f => f.FeatureId == id))
                     .Select(id => new VehicleFeature { FeatureId = id }); //Projection to a VehicleFeatures
                 foreach (var f in addedFeatures)
                     v.Features.Add(f);
              });
        }
    }
}