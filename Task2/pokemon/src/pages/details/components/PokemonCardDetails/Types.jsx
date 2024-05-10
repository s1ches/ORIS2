import React from 'react';

const Types = ({types}) => {
    return (
        <div className="pokemon-details-card-types">
            {types.map(type => (
            <div className="pokemon-type pokemon-details-card-type" style={{backgroundColor: type.typeColor}}>
                {type.typeName[0].toUpperCase() + type.typeName.slice(1)}
            </div>
        ))}
        </div>
    );
};

export default Types;