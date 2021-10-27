﻿using System.ComponentModel.DataAnnotations;

namespace WordCount.JsonModels
{
    public sealed class ArticleJsonModel
    {
        public string ArticleTitle { get; set; }
        public string Publication { get; set; }
        public string FilePath { get; set; }
        public int TotalWordsInArticle { get; set; }
        public TermJsonModel[] Words { get; set; }
    }
}