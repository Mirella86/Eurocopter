using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EurocopterFollowUp.Model.Infrastructure
{
    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            var modelMetadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            attributes.OfType<MetadataAttribute>().ToList().ForEach(x => x.Process(modelMetadata));
            return modelMetadata;
        }
    }
}