﻿using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.GoodReceivedNotes.GetGoodReceivedNote
{
    public class GetGoodReceivedNoteUsecase:UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetGoodReceivedNoteUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<GrnHeaderInfoDto> Execute()
        {
            GoodReceivedNote goodReceivedNote = await unitOfWork.GoodReceivedNotes.Get(Id);
            GrnHeaderInfoDto result = mapper.Map<GoodReceivedNote, GrnHeaderInfoDto>(goodReceivedNote);
            return result;
        }
    }
}
