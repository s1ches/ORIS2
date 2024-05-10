import React from 'react';
import kgToLbs from "../../../functions/kgToLbs";
import meterToFt from "../../../functions/meterToFt";

const BreedingCard = ({pokemon}) => {
    return (
        <div className="pokemon-details-card">
            <div className="pokemon-details-card-header">
                <h2 className="stat-card-header">Breeding</h2>
            </div>
            <div className="pokemon-details-card-content breeding-card-content">
                <div className="breeding-card-stat">
                    <div><p>Height</p></div>
                    <div className="breeding-card-stat-content">
                        <p>{meterToFt(pokemon.breeding.height/10).ft}'{meterToFt(pokemon.breeding.height/10).inch.toString().padStart(2, "0")}'' &nbsp;&nbsp; {pokemon.breeding.height/10} m</p>
                    </div>
                </div>
                <div className="breeding-card-stat">
                    <div><p>Weight</p></div>
                    <div className="breeding-card-stat-content">
                        <p>{kgToLbs(pokemon.breeding.weight)}. lbs &nbsp; {pokemon.breeding.weight} kg</p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default BreedingCard;