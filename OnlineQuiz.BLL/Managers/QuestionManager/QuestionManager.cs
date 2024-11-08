﻿using AutoMapper;
using OnlineQuiz.BLL.Dtos.Options;
using OnlineQuiz.BLL.Dtos.Question;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.QuestionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Managers.QuestionManager
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;

        public QuestionManager(IQuestionsRepository questionsRepository, IMapper mapper)
        {
            _questionsRepository = questionsRepository;
            _mapper = mapper;
        }

        public IQueryable<QuestionDto> GetAllQuestions()
        {
            var questions = _questionsRepository.GetAll(); 
            return _mapper.ProjectTo<QuestionDto>(questions);  // Use ProjectTo for direct mapping to DTO
        }

        public QuestionDto GetQuestionById(int id)
        {
            var question = _questionsRepository.GetById(id);
            return _mapper.Map<QuestionDto>(question);
        }

        public void AddQuestion(createQuestionDto createquestionDto)
        {
            var question = _mapper.Map<Questions>(createquestionDto);
            _questionsRepository.Add(question);
        }

        public void UpdateQuestion(QuestionDto questionDto)
        {
         var question = _mapper.Map<Questions>(questionDto);
            _questionsRepository.Update(question);
        }

        public void DeleteQuestion(int id)
        {
            _questionsRepository.DeleteById(id);
        }
        public void DeleteOption(int optionId)
        {
            _questionsRepository.DeleteOptionById(optionId);
        }
        public OptionDto GetOptionById(int optionId)
        {
            var option = _questionsRepository.GetOptionById(optionId);
            return option != null ? _mapper.Map<OptionDto>(option) : null; // Map to DTO if found
        }

        public async Task AddQuestionAsync(createQuestionDto createQuestionDto)
        {
            var question = _mapper.Map<Questions>(createQuestionDto);

          //handl options 
            foreach (var optionDto in createQuestionDto.Options)
            {
                var option = new Option
                {
                    OptionText = optionDto.OptionText,
                   
                };

                question.Options.Add(option); // Add option to the question's options list
            }

            await _questionsRepository.AddAsync(question);
        }

        public void savechanges()
        {
            _questionsRepository.savechanges(); 
        }
    }
}
