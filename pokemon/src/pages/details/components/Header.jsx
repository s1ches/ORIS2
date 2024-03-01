import React from 'react';
import {Link} from "react-router-dom";

const Header = () => {
    return (
        <div className="finder" style={{paddingBottom: "20px"}}>
            <div className="finder-wrapper">
                <Link className="back-link" to={"/"}><img alt="" className="back" src="https://raw.githubusercontent.com/s1ches/ORIS2/4864b60dad4cadeb97287dae7e0039d456ffbdfc/pokemon/public/icons/arrow.svg"/></Link>
                <img className="pokeball" alt="" src="https://raw.githubusercontent.com/s1ches/ORIS2/4864b60dad4cadeb97287dae7e0039d456ffbdfc/pokemon/public/icons/Pokeball.svg"/>
            </div>
        </div>
    );
};

export default Header;