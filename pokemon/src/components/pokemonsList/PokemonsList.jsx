import React from 'react';
import PokemonCard from "./pokemonCard/PokemonCard";
import NotFound from "../notFound/NotFound";

const PokemonsList = (props) => {
    let pokemons = props.props;

    if(pokemons.length != 0)
        return (
            <div className="pokemon-list">
                <div className="pokemon-list-wrapper">
                    {pokemons.map(pokemon => (<PokemonCard props={pokemon} id={pokemon.id}/>))}
                </div>
            </div>
        );
    else
        return (
            <NotFound />
        )
};

export default PokemonsList;