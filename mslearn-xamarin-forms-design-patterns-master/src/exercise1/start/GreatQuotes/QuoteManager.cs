﻿using GreatQuotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GreatQuotes
{
    public class QuoteManager
    {
        static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());

        public IList<GreatQuoteViewModel> Quotes;

        public static QuoteManager Instance { get => instance.Value; }

        IQuoteLoader loader;



        private QuoteManager()
        {
            loader = QuoteLoaderFactory.Create();
            Quotes = new ObservableCollection<GreatQuoteViewModel>(loader.Load());
        }

        public void Save()
        {
            loader.Save(Quotes);
        }
    }
}
