﻿using Bot.Business.Abstractions.ServicesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Business.Implementation.Services
{
    public class MuteService : IMuteService
    {
        private readonly ISettingsService _settingsService;
        //UnitOfWork here

        public MuteService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            //UnitOfWork here
        }

        public void AddMute(int muteDuration, int userId, int chatId)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMutedUsers(int chatId)
        {
            throw new NotImplementedException();
        }
    }
}