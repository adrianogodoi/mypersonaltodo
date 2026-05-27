using AutoMapper;
using MyPersonalToDo.Api.Application.Interfaces;
using MyPersonalToDo.Api.Responses;
using MyPersonalToDo.Domain.Dtos;
using MyPersonalToDo.Domain.Filters;
using MyPersonalToDo.Domain.Models;
using MyPersonalToDo.Domain.Resources;
using MyPersonalToDo.Domain.ViewModels;
using MyPersonalToDo.Services.Interfaces;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyPersonalToDo.Api.Application
{
    public class ToDoApplication: IToDoApplication
    {
        private readonly IToDoService _service;
        private readonly IMapper _mapper;

        public ToDoApplication(IMapper mapper, IToDoService service) {
            _mapper = mapper;
            _service = service;
        }

        public async Task<ResponseMessage> GetAllAsync(FilterToDoViewModel filter)
        {
            var dto = await _service.GetAllAsync(GetFilterToDo(filter));
            return ResponseMessage.ShowMessage(_mapper.Map<IEnumerable<ToDoDto>>(dto), ResourceMessages.MensagemOperacaoRealizadaComSucesso);
        }

        public async Task<ResponseMessage> Add(ToDoViewModelAdd todoViewModel)
        {
            try
            {
                var entidade = _mapper.Map<ToDo>(todoViewModel);
                var result = await _service.Add(entidade);
                return ResponseMessage.ShowMessage(_mapper.Map<ToDoDto>(result), ResourceMessages.MensagemOperacaoRealizadaComSucesso);
            }
            catch (Exception ex)
            {
                return ResponseMessage.ShowErrors(ResourceMessages.MensagemErroDefault, ex.Message);
            }
        }

        public async Task<ResponseMessage> GetById(long id)
        {
            try
            {
                var result = await _service.GetById(id);
                return ResponseMessage.ShowMessage(_mapper.Map<ToDoDto>(result), ResourceMessages.MensagemOperacaoRealizadaComSucesso);
            }
            catch (Exception ex)
            {
                return ResponseMessage.ShowErrors(ResourceMessages.MensagemErroDefault,ex.Message);
            }
        }

        public async Task<ResponseMessage> Update(ToDoViewModelUpdate todoViewModel)
        {
            try
            {
                var searchToDo = await _service.GetById(todoViewModel.Id);

                if(searchToDo ==  null)
                    return ResponseMessage.ShowErrors(ResourceMessages.MensagemTarefaNaoEncontrada, string.Empty);

                _mapper.Map(todoViewModel, searchToDo);

                var updateResult = await _service.Update(searchToDo);

                return ResponseMessage.ShowMessage(_mapper.Map<ToDoDto>(updateResult), ResourceMessages.MensagemOperacaoRealizadaComSucesso);
            }
            catch (Exception ex)
            {
                return ResponseMessage.ShowErrors(ResourceMessages.MensagemErroDefault, ex.Message);
            }
        }

        public async Task<ResponseMessage> Remove(long id)
        {
            try
            {
                var result = await _service.GetById(id);

                if(result == null)
                    return ResponseMessage.ShowErrors(ResourceMessages.MensagemTarefaNaoEncontrada, string.Empty);

                await _service.Remove(id);

                return ResponseMessage.ShowMessage(_mapper.Map<ToDoDto>(result), ResourceMessages.MensagemTarefaRemovidaComSucesso);
            }
            catch (Exception ex)
            {
                return ResponseMessage.ShowErrors(ResourceMessages.MensagemErroDefault,ex.Message);
            }

        }

        public Expression<Func<ToDo, bool>> GetFilterToDo(FilterToDoViewModel? filter)
        {
            if (filter == null)
                filter = new FilterToDoViewModel();

            return t => (filter.StatusId == null || t.Status == filter.StatusId) &&
                        (filter.DataVencimento == null || t.DataVencimento.Value.Date >= filter.DataVencimento.Value.Date);
        }

    }
}
