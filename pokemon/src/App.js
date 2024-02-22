import "./styles/app.css"
import Finder from "./components/finder/Finder";
import PokemonsList from "./components/pokemonsList/PokemonsList";
import {useEffect, useState} from "react";
import invokePokemons from "./functions/pokemonsInvoker";

function App() {
    const [pokemonName, setPokemonName] = useState('');
    const [pokemons, setPokemons] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const ps = await invokePokemons();
            setPokemons(ps);
        };
        fetchData();
    }, []);

    const findPokemons = (pokemons, pokemonName) => {
        if(pokemonName === '')
            return pokemons;

        let newPokemons = []

        for(let i = 0; i < pokemons.length; ++i){
            if(pokemons[i].name.startsWith(pokemonName.toLowerCase()))
                newPokemons[newPokemons.length] = pokemons[i];
        }

        return newPokemons;
    }

   return (
    <div className="app">
      <Finder onChange={event => setPokemonName(event.target.value)} />
      <PokemonsList props = {findPokemons(pokemons, pokemonName)}/>
    </div>
  );
}

export default App;