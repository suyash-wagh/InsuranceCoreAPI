using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace InsuranceWebApi.ViewModels
{
    public class AddDocumentViewModel
    {
        public string BaseEntityId { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentFile { get; set; }
    }
}
