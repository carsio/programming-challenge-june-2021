import React from 'react';
import logo from './assets/capiflix.png';
import './App.css';

interface ICard {
  title:string;
  rating:number;
}

const App = () => {

  const Card = ({title="", rating=0}:ICard) => {
    let initials = title.substring(0,2);
    return <div className="card">
              <div className="imgTmb">{initials}</div>
                <div className="desc">
                <span>{title}</span>
                <span>⭐{rating}</span>
              </div>
            </div>
  }

  return (
    <div className="wrap">
      <header className="header">
        <img src={logo} alt="Logo capiflix" height="40"/>
      </header>
      <form className="content">
        <select name="genre" className="input border" placeholder="Genres">
          <option value="">Please choose</option>
          <option value="1">Action</option>
          <option value="2">Adventure</option>
          <option value="3">Animation</option>
          <option value="4">Children's</option>
          <option value="5">Comedy</option>
          <option value="6">Crime</option>
          <option value="7">Documentary</option>
          <option value="8">Drama</option>
          <option value="9">Fantasy</option>
        </select>
        <div className="row">
            <input type="number" className="input" name="year" id="year" placeholder="Year" />
            <input type="number" className="input" name="topK" id="topK" placeholder="Top K" />
        </div>
        <div className="row end">
          <button type="submit" className="button-search">Search</button>
        </div>
      </form>
      <div className="content">
          <h3>Movies:</h3>
          <div className="row-card">
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
            <Card title="AAaw " rating={2.3} />
          </div>
      </div>
    </div>
  );
}

export default App;
