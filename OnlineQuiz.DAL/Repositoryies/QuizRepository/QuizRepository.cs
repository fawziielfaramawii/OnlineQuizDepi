﻿using Microsoft.EntityFrameworkCore;
using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.Base;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.QuizRepository
{
    public class QuizRepository :  IRepository<Quizzes, int>, IQuizRepository
    {
        private readonly QuizContext _context;

        public QuizRepository(QuizContext context)
        {
            _context = context;
        }

        public IQueryable<Quizzes> GetAll()
        {
            return _context.Set<Quizzes>().Where(q => !q.IsDeleted).AsQueryable();
        }

        public Quizzes GetById(int id)
        {
            return _context.Set<Quizzes>().FirstOrDefault(q => q.Id == id && !q.IsDeleted);
        }

        public void Add(Quizzes entity)
        {
            _context.Set<Quizzes>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Quizzes entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.quizzes.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

            public void DeleteById(int id)
        {
            var quiz = _context.Set<Quizzes>().FirstOrDefault(q => q.Id == id);
            if (quiz != null)
            {
                quiz.IsDeleted = true; // Mark as soft-deleted
                _context.SaveChanges();
            }
        }

        public IQueryable<Quizzes> GetByTrackId(int trackId)
        {
            return _context.Set<Quizzes>().Where(q => q.TracksId == trackId && !q.IsDeleted);
        }

        public IQueryable<Quizzes> GetAvailableQuizzes()
        {
            return _context.Set<Quizzes>().Where(q => q.IsAvailable && !q.IsDeleted);
        }
        public IQueryable<Quizzes> GetQuizzesWithQuestions()
        {
            return _context.Set<Quizzes>()
                 .Where(q => !q.IsDeleted)
                .Include(q => q.Questions) 
                    .ThenInclude(q => q.Options) 
                .AsQueryable();
        }
        public Quizzes GetQuizByIdWithQuestions(int quizId)
        {
            return _context.quizzes
                .Include(q => q.Questions) 
                .ThenInclude(q => q.Options)
                 .FirstOrDefault(q => q.Id == quizId && !q.IsDeleted);
        }
    }
}
