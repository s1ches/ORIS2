import React from 'react';
import PokemonType from "./pokemonType/PokemonType";
import {Link} from "react-router-dom";
import typeToColor from "../../../../../functions/typeToColor";

const PokemonCard = (props) => {
    let pokemon = props.props;

    return (
        <Link to={`details/${pokemon.name}`}>
        <div className="pokemon-card">
            <div className="card-header">
                <div className="pokemon-name">
                    {pokemon?.name[0].toUpperCase() + pokemon?.name.slice(1)}
                </div>
                <div className="pokemon-id">
                    #{pokemon?.id.toString().padStart(3, '0')}
                </div>
            </div>
            <div className="card-content">
                <img alt="" className="card-image" src={pokemon?.imageUrl}/>
            </div>
            <div className="card-footer">
                {pokemon?.types.map(type => (
                    <PokemonType style={{background: typeToColor(type)}}> {type}</PokemonType>))}
            </div>
        </div>
        </Link>
    );
};

export default PokemonCard;