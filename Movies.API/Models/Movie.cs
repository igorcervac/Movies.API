﻿using System;
using System.Collections.Generic;

namespace Movies.API.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string? ImdbId { get; set; }

    public string? Type { get; set; }

    public string? Title { get; set; }

    public string? Year { get; set; }

    public string? Poster { get; set; }
}
