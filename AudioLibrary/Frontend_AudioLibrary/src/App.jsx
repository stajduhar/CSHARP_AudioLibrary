import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import NavbarEdunova from './components/NavBarEdunova';
import { Route, Routes } from 'react-router-dom';
import { RoutesNames } from './constants';
import Pocetna from './pages/Pocetna';
import GenresOverview from './pages/genres/GenresOverview';
import GenresAdd from './pages/genres/GenresAdd';
import GenresChange from './pages/genres/GenresChange';


function App() {



  return (
<>
 <NavbarEdunova />
 <Routes>
  <Route path={RoutesNames.HOME} element={<Pocetna />} />
  
  <Route path={RoutesNames.GENRES_OVERVIEW} element={<GenresOverview />} />
  <Route path={RoutesNames.GENRE_NEW} element={<GenresAdd />} />
  <Route path={RoutesNames.GENRE_CHANGE} element={<GenresChange />} />
 </Routes>
</>
  );
}

export default App
