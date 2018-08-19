using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Controllers.Repository;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Controllers.Logic
{
    public class ScheduleLogic : IScheduleLogic
    {
        private readonly IScheduleRepo _repo;
        private readonly IMapper _mapper;
        
        public ScheduleLogic(IScheduleRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ScheduleViewModel>> GetAllAsync()
        {
            var Schedules = await _repo.GetAllAsync();
            var viewSchedules = _mapper.Map<List<ScheduleViewModel>>(Schedules);
            return viewSchedules;
        }
        public async Task PostAsync(ScheduleViewModel viewModel)
        {
            var scheduleModel = _mapper.Map<Schedule>(viewModel);
            var modelId = await _repo.PostAsync(scheduleModel);
        }

        public async Task PutAsync(ScheduleViewModel viewModel)
        {
            var model = _mapper.Map<Schedule>(viewModel);
                        
            await _repo.PutAsync(model);
        }
        public async Task DeleteAllAsync()
        {
            await _repo.DeleteAllAsync();
        }
    }
}