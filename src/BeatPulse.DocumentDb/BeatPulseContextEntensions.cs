﻿using BeatPulse.Core;
using System;

namespace BeatPulse.DocumentDb
{
    public static class BeatPulseContextEntensions
    {
        public static BeatPulseContext AddDocumentDb(this BeatPulseContext context, Action<DocumentDbOptions> options, string defaultPath = "documentdb")
        {
            var documentDbOptions = new DocumentDbOptions();
            options(documentDbOptions);

            context.AddLiveness(nameof(DocumentDbLiveness), setup =>
            {
                setup.UsePath(defaultPath);
                setup.UseLiveness(new DocumentDbLiveness(documentDbOptions));
            });
            return context;
        }
    }
}
