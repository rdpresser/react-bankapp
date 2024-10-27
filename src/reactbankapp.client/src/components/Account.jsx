import { useEffect, useState } from 'react';
import Header from './Header'

function Account() {
    const [data, setData] = useState();

    useEffect(() => {
        populateData();
    }, []);

    const contents = data === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Account Number</th>
                    <th>Customer Name</th>
                    <th>Currency</th>
                    <th>Balance</th>
                    <th>Account Type</th>
                </tr>
            </thead>
            <tbody>
                {data.map(item =>
                    <tr key={item.id}>
                        <td>{item.accountNumber}</td>
                        <td>{item.customerName}</td>
                        <td>{item.currency}</td>
                        <td>{item.balance}</td>
                        <td>{item.accountType}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <Header title='Menu' />
            <h1 id="tableLabel">Customer List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateData() {
        const response = await fetch('/api/account');
        const data = await response.json();
        setData(data);
    }
}

export default Account;