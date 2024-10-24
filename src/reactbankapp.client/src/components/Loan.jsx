import { useEffect, useState } from 'react';
import Header from './Header'

function Loan() {
    const [data, setData] = useState();

    useEffect(() => {
        populateData();
    }, []);

    const contents = data === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Amount</th>
                    <th>Rate</th>
                    <th>Start Date</th>
                    <th>End Date</th>
                </tr>
            </thead>
            <tbody>
                {data.map(item =>
                    <tr key={item.id}>
                        <td>{item.amount}</td>
                        <td>{item.interestRate}</td>
                        <td>{item.startDate}</td>
                        <td>{item.endDate}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <Header title='Menu' />
            <h1 id="tableLabel">Loan List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateData() {
        const response = await fetch('/api/loan');
        const data = await response.json();
        setData(data);
    }
}

export default Loan;