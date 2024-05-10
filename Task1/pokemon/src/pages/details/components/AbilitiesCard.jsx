import React from 'react';
import getRandomColor from "../../../functions/getRandomColor";

const AbilitiesCard = ({pokemon}) => {
    return (
        <div className="pokemon-details-card">
            <div className="pokemon-details-card-header moves-card-header-block">
                <h2 className="stat-card-header moves-card-header">Abilities</h2>
            </div>
            <div className="pokemon-details-card-content moves-card-content">
                {pokemon.abilities.slice(0, 2).map(ability => (
                    <div className="pokemon-details-card-content-move" style={{backgroundColor: getRandomColor()}}>
                        {ability[0].toUpperCase() + ability.slice(1).replace("-", " ")}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default AbilitiesCard;