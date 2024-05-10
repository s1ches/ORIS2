import React from 'react';

const Stats = ({stats}) => {
    return (
        <div className="stats-block">
            <div className="stat">
                <p>
                    HP
                </p>
                <div className="stat-bar" style={{backgroundColor: "rgba(94, 212, 152, 0.5)"}}>
                    <div className="stat-fill" style={{width: `${(stats.hp / 255) * 100}%`, backgroundColor: "#5ED498"}}></div>
                </div>
            </div>
            <div className="stat">
                <p>
                    Attack
                </p>
                <div className="stat-bar" style={{backgroundColor: "rgba(241, 79, 66, 0.5)"}}>
                    <div className="stat-fill" style={{width: `${(stats.attack / 190) * 100}%`, backgroundColor: "#F14F42"}}></div>
                </div>
            </div>
            <div className="stat">
                <p>
                    Defence
                </p>
                <div className="stat-bar" style={{backgroundColor: "rgba(252, 216, 93, 0.5)"}}>
                    <div className="stat-fill" style={{width: `${(stats.defense / 230) * 100}%`, backgroundColor: "#FCD85D"}}></div>
                </div>
            </div>
            <div className="stat">
                <p>
                    Speed
                </p>
                <div className="stat-bar" style={{backgroundColor: "rgba(255, 132, 80, 0.5)"}}>
                    <div className="stat-fill" style={{width: `${(stats.speed / 180) * 100}%`, backgroundColor: "#FF8450"}}></div>
                </div>
            </div>
        </div>
    );
};

export default Stats;