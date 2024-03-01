const meterToFtOnly = (meter) => (meter * (3.281)).toFixed(0);

const meterToInchRemainder= (meter) => Math.ceil(((meter * (3.281)) - meterToFtOnly(meter)) * 12);

const meterToFt = (meter) => {return {ft: meterToFtOnly(meter), inch: meterToInchRemainder(meter)}};

export default meterToFt;
