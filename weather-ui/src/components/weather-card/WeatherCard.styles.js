import styled from "styled-components";

const tempColor = (temp) => {
  if (temp < 5) return "#3b82f6";
  if (temp < 20) return "#6366f1";
  return "#ef4444";
};

export const Card = styled.div`
  margin-top: 34px;
  padding: 24px;
  width: 340px;
  border-radius: 18px;
  background: ${({ theme }) => (theme.mode === "dark" ? "#111827" : "#f9fafb")};
  color: ${({ theme }) => (theme.mode === "dark" ? "#f9fafb" : "#111827")};
  transition: all 0.3s ease;
  &:hover {
    transform: translateY(-6px);
  }
`;

export const City = styled.h2`
  margin: 0;
  font-size: 22px;
`;
export const Description = styled.p`
  margin: 6px 0 18px;
  opacity: 0.8;
  text-transform: capitalize;
`;
export const Temperature = styled.div`
  font-size: 52px;
  font-weight: 700;
  color: ${({ temp }) => tempColor(temp)};
`;
export const InfoRow = styled.div`
  display: flex;
  justify-content: space-between;
  margin-top: 16px;
  font-size: 14px;
`;
