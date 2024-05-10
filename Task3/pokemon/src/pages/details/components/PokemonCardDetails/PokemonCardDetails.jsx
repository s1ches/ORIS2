import React from 'react';
import Types from "./Types";
import Stats from "./Stats";

const PokemonCardDetails = ({pokemon}) => {
    return (
        <div className="pokemon-details-card">
            <div className="pokemon-details-card-header">
                <div className="pokemon-details-card-header-name_id">
                    <p>#{pokemon?.id.toString().padStart(3, '0')}</p>
                    <h2 className="pokemon-details-card-name">{pokemon?.name[0].toUpperCase() + pokemon?.name.slice(1)}</h2>
                </div>
                <Types types={pokemon?.types} />
            </div>
            <div className="pokemon-details-card-content">
                <Stats stats={pokemon?.stats} />
                <img alt="" className="pokemon-details-card-img" src={pokemon.imageUrl} />
            </div>
        </div>
    );
};

export default PokemonCardDetails;