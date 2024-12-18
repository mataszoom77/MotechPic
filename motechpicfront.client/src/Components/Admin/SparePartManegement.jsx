import { useEffect, useState } from "react";
import PropTypes from "prop-types";
import api from "../../services/api";

const SparePartList = ({ productId }) => {
    const [spareParts, setSpareParts] = useState([]);

    useEffect(() => {
        api.getSpareParts(productId).then((res) => setSpareParts(res.data));
    }, [productId]);

    return (
        <div>
            <h2>Spare Parts</h2>
            <ul>
                {spareParts.map((part) => (
                    <li key={part.id}>{part.name}</li>
                ))}
            </ul>
        </div>
    );
};

SparePartList.propTypes = {
    productId: PropTypes.number.isRequired,
};

export default SparePartList;
