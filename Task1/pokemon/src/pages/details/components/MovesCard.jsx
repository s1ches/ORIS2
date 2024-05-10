import React from 'react';
import getRandomColor from "../../../functions/getRandomColor";

const MovesCard = ({pokemon}) => {
    return (
        <div className="pokemon-details-card">
            <div className="pokemon-details-card-header moves-card-header-block">
                <h2 className="stat-card-header moves-card-header">Moves</h2>
            </div>
            <div className="pokemon-details-card-content moves-card-content">
                {pokemon.moves.slice(0, 6).map(move => (
                    <div className="pokemon-details-card-content-move" style={{backgroundColor: getRandomColor()}}>
                        {move[0].toUpperCase()+move.slice(1).replace("-", " ")}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default MovesCard;