const SearchBar = ({ city, setCity, onSearch }) => (
  <div style={{ marginTop: 20 }}>
    <input
      type="text"
      value={city}
      onChange={(e) => setCity(e.target.value)}
      placeholder="Enter city..."
      style={{ padding: 8, borderRadius: 6, border: "1px solid #ccc" }}
    />
    <button
      onClick={onSearch}
      style={{ padding: 8, marginLeft: 8, borderRadius: 6 }}
    >
      Search
    </button>
  </div>
);

export default SearchBar;
