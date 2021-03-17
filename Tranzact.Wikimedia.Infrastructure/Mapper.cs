using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Infrastructure.Interfaces;
using Tranzact.Wikimedia.Services.Models;

namespace Tranzact.Wikimedia.Infrastructure
{
    public class Mapper : IMapper
    {
        public WikimediaDto MapFromEntityToDto(WikimediaEntity entity)
        {
            return new WikimediaDto
            {
                day = entity.day,
                extension = entity.extension,
                hour = entity.hour,
                month = entity.month,
                name = entity.name,
                year = entity.year,
                path = entity.path,
                nameFile = entity.nameFile,
                localPath = entity.localPath

            };
        }

            public WikimediaEntity MapFromDtoToEntity(WikimediaDto dto)
            {
                return new WikimediaEntity
                {
                    day = dto.day,
                    extension = dto.extension,
                    hour = dto.hour,
                    month = dto.month,
                    name = dto.name,
                    year = dto.year,
                    localPath = dto.localPath

                };
            }
        }
}
