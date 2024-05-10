import React from 'react';
import PokemonCard from "./pokemonCard/PokemonCard";
import NotFound from "../notFound/NotFound";
import Loading from "../../../../components/Loading";

const PokemonsList = ({pokemons, isLoading}) => {
    if(pokemons.length !== 0 && !isLoading) {
        return (
            <div className="pokemon-list">
                <div className="pokemon-list-wrapper">
                    {pokemons.map(pokemon => (<PokemonCard props={pokemon} id={pokemon.id}/>))}
                </div>
            </div>
        );

    }
    if(!isLoading)
        return (
            <NotFound />
        )

    return (
        <>
            <div className="pokemon-list">
                <div className="pokemon-list-wrapper">
                    {pokemons.map(pokemon => (<PokemonCard props={pokemon} id={pokemon.id}/>))}
                </div>
            </div>
            <Loading/>
        </>
    )
};

export default PokemonsList;