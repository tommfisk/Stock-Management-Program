using Entities;

namespace DTOs
{
    public class MemberConverter : Converter<MemberDTO, Member>
    {
        public Member ConvertDtoToEntity(MemberDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return
                new MemberBuilder()
                    .WithId(dto.ID)
                    .WithName(dto.Name)
                .Build();
        }

        public MemberDTO ConvertEntityToDto(Member entity)
        {
            if (entity == null)
            {
                return null;
            }

            return
                new MemberDTO_Builder()
                    .WithId(entity.ID)
                    .WithName(entity.Name)
                .Build();
        }
    }
}
