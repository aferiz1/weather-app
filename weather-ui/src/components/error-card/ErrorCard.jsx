import styled from "styled-components";

const Card = styled.div`
  margin-top: 20px;
  padding: 20px;
  border-radius: 12px;
  background: #ffe5e5;
  color: #b00020;
  font-weight: bold;
  text-align: center;
  min-width: 250px;
`;

const ErrorCard = ({ message }) => {
  return <Card>{message}</Card>;
};

export default ErrorCard;
