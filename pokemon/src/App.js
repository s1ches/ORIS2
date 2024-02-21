import "./styles/app.css"
import Finder from "./components/finder/Finder";
import PokemonsList from "./components/pokemonsList/PokemonsList";

function App() {
  return (
    <div className="app">
      <Finder />
      <PokemonsList />
    </div>
  );
}

export default App;