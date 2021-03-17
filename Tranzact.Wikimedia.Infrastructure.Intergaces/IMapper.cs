using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Services.Models;

namespace Tranzact.Wikimedia.Infrastructure.Interfaces
{
    public interface IMapper
    {
        WikimediaDto MapFromEntityToDto(WikimediaEntity entity);
        WikimediaEntity MapFromDtoToEntity(WikimediaDto entity);
    }
}
