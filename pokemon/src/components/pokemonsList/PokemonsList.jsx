import React, {useEffect, useState} from 'react';

const PokemonsList = () => {
    async function getPokemons() {
        const response = await fetch("https://pokeapi.co/api/v2/pokemon?limit=10&offset=0");
        const pokemonListJson = await response.json();
        return pokemonListJson?.results;
    }

    const [pokemonsList, setPokemonsList] = useState([]);

    useEffect(() => {
            getPokemons().then(pokemons => setPokemonsList(pokemons)).catch(error => console.error(error));
        }, []);

    console.log(pokemonsList);

    // TODO: 1. get all pokemons from https://pokeapi.co/api/v2/pokemon?limit=10&offset=0.
    // TODO: 2. from results of todo1 get the name and url
    // TODO: 3. from url get forms, from form get name and url
    // TODO: 4. from url get types and their names

    return (
        <div className="pokemon-list">
            <div className="pokemon-list-wrapper">
                <div className="pokemon-card">
                    {pokemonsList[0]?.name}
                </div>
            </div>
        </div>
    );
};

export default PokemonsList;