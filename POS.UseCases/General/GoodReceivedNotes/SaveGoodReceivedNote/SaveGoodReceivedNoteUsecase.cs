using System.Threading.Tasks;
using POS.Core.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using System;
using POS.Models.Enums;

namespace POS.UseCases.General.GoodReceivedNotes.SaveGoodReceivedNote
{
    public class SaveGoodReceivedNoteUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GrnSaveDto Dto { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }

        public SaveGoodReceivedNoteUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<GrnHeaderInfoDto> Execute()
        {
            #region Insert GRN

            GoodReceivedNote grnHeader = mapper.Map<GrnSaveDto, GoodReceivedNote>(Dto);
            grnHeader.CreatedOn = DateTime.Now;
            grnHeader.CreatedBy = this.CreatedBy;
            grnHeader.CreatedByName = CreatedByName;
            grnHeader.Time = DateTime.Now;
            List<GoodReceivedNoteItem> details = mapper.Map<List<GrnSaveDetail>, List<GoodReceivedNoteItem>>(Dto.Items);
            grnHeader.Items = details;
            unitOfWork.GoodReceivedNotes.Add(grnHeader);

            #endregion

            #region Update Inventory

            //foreach (var grnItem in details)
            //{
            //    Inventory invntry = new Inventory();
            //    invntry.ItemId = grnItem.
            //}

            #endregion


            await unitOfWork.Complete();
            var headerDto = this.mapper.Map<GoodReceivedNote, GrnHeaderInfoDto>(grnHeader);
            return headerDto;
        }
    }
}
