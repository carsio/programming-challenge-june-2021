import React, { FormEvent, FormEventHandler, useEffect, useState } from 'react';
import logo from './assets/capiflix.png';
import './App.css';
import { IMovie } from './interfaces/IMovie';
import { IGender } from './interfaces/IGender';
import { movieService } from './services/movie.service';

interface ICard {
  title:string;
  rating:number;
}

const App = () => {

  const [genres, setGenres] = useState([] as IGender[]);
  const [movies, setMovies] = useState([] as IMovie[]);
  const [year, setYear] = useState('');
  const [gender, setGender] = useState('');
  const [topK, setTopK] = useState('');

  useEffect(() => {
    load();
  }, []);

  const load = async () : Promise<void> => {
    const gnrs = await movieService.getGenres();
    setGenres(gnrs.data);
  }

  const onSubmit = async (e: FormEvent) : Promise<void> => {
    e.preventDefault();
    console.log(year, gender, topK);
    const moviesResponse = await movieService.getMovies(year, gender, topK);
    setMovies(moviesResponse.data);
  }

  //const limitTitle = 

  const Card = ({title="", rating=0}:ICard) => {
    let initials = title.substring(0,2);
    return <div className="card">
              <div className="imgTmb">{initials}</div>
                <div className="desc">
                <span className="title" title={title}>{title}</span>
                <span>⭐{rating}</span>
              </div>
            </div>
  }

  return (
    <div className="wrap">
      <header className="header">
        <img src={logo} alt="Logo capiflix" height="40"/>
      </header>
      <form className="content" onSubmit={onSubmit}>
        <select name="genre" className="input border" placeholder="Genres" onChange={e => setGender(e.target.value)}>
          <option value="">Please choose</option>
          {genres.map(g => (
            <option value={g.id}>{g.name}</option>
          ))}
        </select>
        <div className="row">
          <input type="number" className="input" name="year" id="year" placeholder="Year" onChange={e => setYear(e.target.value)} />
          <input type="number" className="input" name="topK" id="topK" placeholder="Top K" onChange={e => setTopK(e.target.value)} />
        </div>
        <div className="row end">
          <button type="submit" className="button-search">Search</button>
        </div>
      </form>
      <div className="content">
          <h3>Movies:</h3>
          <div className="row-card">
            {movies.map(m => (
              <Card title={m.title} rating={m.rating} />
            ))}
          </div>
      </div>
    </div>
  );
}

export default App;
