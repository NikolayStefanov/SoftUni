import './App.css';
import SportsList from './components/SportsList.js'

const sports = [
  {sport:'Football'},
  {sport:'Bascketball'},
  {sport:'Street Fitness'},
  {sport:'Swimming'},
  {sport:'Walking'}
]

function App() {
  return (
    <div className="App">
      <SportsList sports={sports}/>
    </div>
  );
}

export default App;
