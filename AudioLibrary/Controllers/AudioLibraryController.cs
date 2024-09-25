

using AudioLibrary.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AudioLibrary.Controllers
{
    public abstract class AudioLibraryController:ControllerBase
    {

        // dependency injection
        // 1. definiras privatno svojstvo
        protected readonly AudioLibraryContext _context;

        protected readonly IMapper _mapper;



        // dependency injection
        // 2. proslijediš instancu kroz konstruktor
        public AudioLibraryController(AudioLibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


    }
}
