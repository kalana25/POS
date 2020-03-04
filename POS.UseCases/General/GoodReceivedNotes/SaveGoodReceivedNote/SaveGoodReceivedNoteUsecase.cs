using System.Threading.Tasks;
using POS.Core.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.GoodReceivedNotes.SaveGoodReceivedNote
{
    public class SaveGoodReceivedNoteUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GoodReceivedNoteSaveDto Dto { get; set; }

        public SaveGoodReceivedNoteUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<GrnHeaderInfoDto> Execute()
        {
            GoodReceivedNote header = mapper.Map<GoodReceivedNoteSaveDto, GoodReceivedNote>(Dto);
            List<GoodReceivedNoteItem> details = mapper.Map<List<GoodReceivedNoteSaveDetail>, List<GoodReceivedNoteItem>>(Dto.Items);
            header.Items = details;
            unitOfWork.GoodReceivedNotes.Add(header);
            await unitOfWork.Complete();
            var headerDto = this.mapper.Map<GoodReceivedNote, GrnHeaderInfoDto>(header);
            return headerDto;
        }
    }
}
