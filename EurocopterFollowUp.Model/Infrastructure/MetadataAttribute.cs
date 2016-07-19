using System;
using System.Web.Mvc;

namespace EurocopterFollowUp.Model.Infrastructure
{
    public abstract class MetadataAttribute : Attribute
    {
        public abstract void Process(ModelMetadata modelMetaData);
    }
}