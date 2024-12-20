import { useState, useEffect } from 'react';
import {
  Box,
  TextField,
  Button,
  RadioGroup,
  FormControlLabel,
  Radio,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Container,
  Typography,
  LinearProgress,
  Checkbox
}
  from '@mui/material';
import { useI18nContext } from '@ShareCores';
import { Trans } from 'react-i18next';
import { useGetSeoPosition } from '@ShareHooks'
import {
  SeoPosition,
} from "@ShareModels";

export const Home = () => {
  const { t } = useI18nContext();
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isGetCurrentData, setIsGetCurrentData] = useState<boolean>(false);
  const [provider, setProvider] = useState('');
  const [url, setUrl] = useState('');
  const [keyword, setKeyword] = useState('');
  const { GetSeoPosition, isSuccess, isError, ouput: SeoPositionData } = useGetSeoPosition();
  const [urlError, setUrlError] = useState(false);
  const [keywordError, setKeywordError] = useState(false);

  const handleCheckSEO = () => {
    let valid = true;

    if (!url) {
      setUrlError(true);
      valid = false;
    } else {
      setUrlError(false);
    }

    if (!keyword) {
      setKeywordError(true);
      valid = false;
    } else {
      setKeywordError(false);
    }

    if (valid) {
      setIsLoading(true);
      GetSeoPosition({
        keyword,
        url,
        provider,
        isGetCurrentData,
      })
    }
  };

  useEffect(() => {
    if (isError || isSuccess) {
      setIsLoading(false);
    }
  }, [isSuccess, isError]);

  return (
    <Container
      sx={{
        height: '100vh',
        width: '100%',
        padding: '40px',
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
      }}
    >
      <Typography variant="h3" gutterBottom>
        SEO Checker
      </Typography>

      <Box sx={{ width: '100%', mb: 2 }}>
        <RadioGroup
          row
          value={provider}
          onChange={(e) => setProvider(e.target.value)}
          sx={{ justifyContent: 'center' }}
        >
          <FormControlLabel value="Google" control={<Radio />} label="Google" />
          <FormControlLabel value="Bing" control={<Radio />} label="Bing" />
          <FormControlLabel value="" control={<Radio />} label="All" />
        </RadioGroup>
      </Box>

      <Box sx={{ width: '100%', maxWidth: 600 }}>
        <TextField
          label="URL"
          variant="outlined"
          value={url}
          onChange={(e) => setUrl(e.target.value)}
          fullWidth
          margin="normal"
          required
          error={urlError}
          helperText={urlError ? "This field is required" : ""}
        />
        <TextField
          label="Search Phrase"
          variant="outlined"
          value={keyword}
          onChange={(e) => setKeyword(e.target.value)}
          fullWidth
          margin="normal"
          required
          error={keywordError}
          helperText={keywordError ? "This field is required" : ""}
        />
        <Box sx={{ width: '100%', display: 'flex', justifyContent: 'space-between', mt: 3 }}>
          <Button
            variant="contained"
            color="primary"
            onClick={handleCheckSEO}
            sx={{
              height: 50,
              width: 200,
              marginTop: 2,
              borderRadius: 3,
              boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',
              '&:hover': {
                backgroundColor: '#388e3c',
              },
            }}
          >
            Check SEO
          </Button>
          <FormControlLabel
            control={
              <Checkbox
                checked={isGetCurrentData}
                onChange={() => setIsGetCurrentData(!isGetCurrentData)}
                color="primary"
              />
            }
            label="Get current data"
            sx={{ marginTop: 2 }}
          />
        </Box>
      </Box>

      {isLoading && (
        <Box sx={{ width: '100%', mt: 3 }}>
          <LinearProgress />
        </Box>
      )}

      <Box sx={{ width: '100%', mt: 3, overflowX: 'auto' }}>
        <Table sx={{ borderCollapse: 'separate', borderSpacing: '0 15px' }}>
          <TableHead>
            <TableRow sx={{ backgroundColor: '#4caf50', color: '#fff' }}>
              <TableCell sx={{ fontWeight: 'bold', textAlign: 'center', padding: '12px', fontSize: '16px', color: '#fff' }}>
                Provider
              </TableCell>
              <TableCell sx={{ fontWeight: 'bold', textAlign: 'center', padding: '12px', fontSize: '16px', color: '#fff' }}>
                Position
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {SeoPositionData?.data.map((result, index) => (
              <TableRow
                key={index}
                sx={{
                  '&:hover': { backgroundColor: '#f5f5f5' },
                  boxShadow: '0 2px 8px rgba(0, 0, 0, 0.1)',
                  transition: 'background-color 0.3s ease',
                }}
              >
                <TableCell
                  sx={{
                    padding: '12px',
                    fontSize: '14px',
                    textAlign: 'center',
                    border: '1px solid #ddd',
                    borderRadius: '8px',
                  }}
                >
                  {result.provider}
                </TableCell>
                <TableCell
                  sx={{
                    padding: '12px',
                    fontSize: '14px',
                    textAlign: 'center',
                    border: '1px solid #ddd',
                    borderRadius: '8px',
                  }}
                >
                  {result.positions.map((position, idx) => (
                    <Typography
                      key={idx}
                      variant="body2"
                      color="text.secondary"
                      sx={{
                        display: 'inline', 
                        marginRight: '5px', 
                      }}
                    >
                      {position}{idx < result.positions.length - 1 && ';'}
                    </Typography>
                  ))}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </Box>
    </Container>
  );
};

export default Home;
