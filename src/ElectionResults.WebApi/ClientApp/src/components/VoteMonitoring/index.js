import React from "react";
import "./style.css";

const NumberArea = ({ bigNumber, text }) => (
  <div className={"vote-monitoring-area"}>
    <p className={"area-number"}>{bigNumber}</p>
    <p className={"area-text"}>{text}</p>
  </div>
);
export const VoteMonitoring = ({ voteMonitoringData }) => {
  let messagesNumber;
  let messagesWithProblems;
  let percent;
  if (!voteMonitoringData) {
    return null;
  } else {
    const messagesNumber = voteMonitoringData[0].value;
    const messagesWithProblems = voteMonitoringData[5].value;
    const percent = (messagesWithProblems / messagesNumber) * 100;
    return (
      <div className={"full-width-container"}>
        <div className={"vote-monitoring-container"}>
          <div className={"vote-monitoring-title"}>
            <h1>OBSERVAREA INDEPENDENTĂ A ALEGERILOR</h1>
          </div>
          <div className={"vote-monitoring-numbers"}>
            {NumberArea({
              bigNumber: voteMonitoringData[1].value,
              text: "Secții de votare"
            })}
            {NumberArea({
              bigNumber: voteMonitoringData[2].value,
              text: "Județe acoperite"
            })}
            {NumberArea({
              bigNumber: voteMonitoringData[4].value,
              text: "Observatori în secții"
            })}
          </div>
          <div className={"vote-monitoring-info"}>
            <div className={"info-legend"}>
              <div className={"legend-container space"}>
                <div className={"square left"}></div>
                <p>Mesaje trimise de către observatori</p>
              </div>
              <div className={"legend-container"}>
                <div className={"square right"}></div>
                <p>Probleme sesizate</p>
              </div>
            </div>
            <div className={"info-legend bars"}>
              <div className={"parent-bar"}>
                <p style={{ marginLeft: `${percent + 3}%` }}>
                  {voteMonitoringData[0].value}
                </p>
              </div>
              <div
                style={{
                  width: `${percent}%`
                }}
                className={"child-bar"}
              >
                <p>{voteMonitoringData[5].value}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
};